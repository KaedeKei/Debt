namespace Shedule.Data
{
    public class UsersStatus
    {
        public int Id { get; set; }
        public string Admin { get; set; }
        public string Supervisor { get; set; }
        public string User { get; set; }

        public UsersStatus()
        {
            Admin = "администратор";
            Supervisor = "руководитель направления";
            User = "пользователь";
        }
    }
}
