using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Orders.Domain.Commands.Contracts;
using Orders.Domain.Entities;
using Orders.Domain.Enums;

namespace Orders.Domain.Commands
{
    public class CreateImportCommand : Notifiable, ICommand
    {
        public CreateImportCommand()
        {
            Items = new List<CreateImportItemCommand>();
        }
        public CreateImportCommand(FileExtension fileExtension, IList<CreateImportItemCommand> items)
        {
            FileType = fileExtension;
            Items = items;
        }

        public FileExtension FileType { get; private set; }

        public IList<CreateImportItemCommand> Items { get; private set; }

        public void Validate()
        {
        }
    }
}
