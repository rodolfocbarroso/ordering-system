using System;
using System.Collections.Generic;
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
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, os dados do arquivo estão inconsistentes!", command.Notifications);

            var import = new Import(command.FileType);
            foreach (var item in command.Items)
            {
                import.AddItem(item.Line, item.Name, item.DeliveryDate, item.Quantity, item.UnitPrice);
            }

            AddNotifications(import.Notifications);

            if (Invalid)
                return new GenericCommandResult(false, "Falha ao importar o arquivo.", Notifications);

            _importRepository.Save(import);
            return new GenericCommandResult(true, "Importação do arquivo gerada com sucesso!", import.Id);
        }

        public void Handle()
        {
        }
    }
}
