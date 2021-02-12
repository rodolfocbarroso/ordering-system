using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Flunt.Notifications;
using Orders.Domain.Commands;
using Orders.Domain.Commands.Contracts;
using Orders.Domain.Entities;
using Orders.Domain.Enums;
using Orders.Domain.Handlers.Contracts;
using Orders.Domain.Repositories.Contracts;

namespace Orders.Domain.Handlers
{
    public class ImportHandler :
        Notifiable,
        IHandler<CreateImportCommand>
    {
        private readonly IImportRepository _importRepository;

        public ImportHandler(IImportRepository importRepository)
        {
            _importRepository = importRepository;
        }

        public ICommandResult Handle(CreateImportCommand command)
        {
            var import = new Import(command.FileExtension);
            foreach (var item in command.Items)
            {
                import.AddItem(item.Line, item.Name, item.DeliveryDate, item.Quantity, item.UnitPrice);
            }

            var importItemsInvalid = import.Items
                .Where(importItem => importItem.Notifications.Count > 0)
                .Select(importItem => new { line = importItem.Line, notifications = importItem.Notifications })
                .ToList();

            if (importItemsInvalid.Count > 0)
                return new GenericCommandResult(false, "Falha ao importar o arquivo!", importItemsInvalid);

            _importRepository.Save(import);

            return new GenericCommandResult(true, "Importação de arquivo gerada com sucesso.", new { id = import.Id });
        }
    }
}
