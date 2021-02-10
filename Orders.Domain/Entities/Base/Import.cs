using System;
using System.Collections.Generic;
using System.Text;
using Orders.Domain.Entities.Base;
using Orders.Domain.Enums;

namespace Orders.Domain.Entities.Base
{
    public abstract class Import : Entity
    {
        protected Import(FileExtension fileExtension, ImportStatus importStatus)
        {
            Instant = DateTime.Now;
            FileType = fileExtension;
            ImportStatus = importStatus;
        }

        public DateTime Instant { get; private set; }
        public ImportStatus ImportStatus { get; private set; }
        public FileExtension FileType { get; private set; }
    }
}
