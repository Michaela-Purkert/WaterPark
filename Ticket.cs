using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WaterPark
{
    internal class Ticket
    {
        private int ticketId;
        private DateOnly creationDate;
        private DateOnly expirationDate;

        public int ID
        {
            get { return ticketId; }
            private set { ticketId = value; }
        }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly CreationDate
        {
            get { return creationDate; }
            private set { creationDate = value; }
        }

       [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly ExpirationDate
        {
            get { return expirationDate; }
            private set { expirationDate = value; }
        }

        public Ticket(int ID, DateOnly creationDate, DateOnly expirationDate)
        {
            this.ID = ID;
            this.creationDate = creationDate;
            this.expirationDate = expirationDate;
        }

        public Ticket (int ID)
        {
            this.ID = ID;
            creationDate = new DateOnly(2022, 1, 1);
            expirationDate = new DateOnly(2022, 1, 8);
        }
    }
}
