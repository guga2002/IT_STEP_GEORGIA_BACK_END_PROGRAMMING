

namespace ConsoleAPP.AtmConsoleApp.Entities
{
    public class BankAccount:BaseEntity
    {
        public string UserId { get; set; }//am cvladit vamowmebt vis ekutvnis account , baza ro ghvqonde sgamoviyenebdit 1:N relations

        public decimal Balance { get; set; }

        public string BankName { get; set; }

        public string ClientType { get; set; }

        public BankAccount(string userid,decimal  bLance,string BankName,string clientype):base()
        {
            this.UserId = userid;
            this.Balance = bLance;
            this.BankName = BankName;
            this.ClientType = clientype;
        }
        public BankAccount() : base()
        {
                
        }
        public override string ToString()
        {
            return $"{base.ToString()}  UserID:{UserId};Balance:{Balance};BankName:{BankName};ClientType:{ClientType};\n";
        }
    }
}
