using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.StudentManagementSystemApp.Entities
{
    public abstract class AbstractEntity
    {
        public string Identificator { get; set; }

        protected AbstractEntity(string Identific)
        {
            this.Identificator = Identific;
            inicialize();
        }

        public AbstractEntity()
        {
            inicialize();
        }

        public override string ToString()
        {
            return $"ID:{Identificator};";
        }

        private void inicialize()
        {
            Random rnd = new Random();
            string rand = "ecb252044b5ea0f679ee78ec1a12904739e2904d";
            string identif = "";
            for (int i = 0; i < 15; i++)
            {
                identif += rand[rnd.Next(0, rand.Length - 1)];
            }
            this.Identificator = identif;
        }
    }
}
