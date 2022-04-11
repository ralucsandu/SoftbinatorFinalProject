namespace FinalProject.Entities
{
    public class Obiect
    {
        public int Id { get; set; }
        public string ObiectName { get; set; }
        public int GiftId { get; set; }
        public Gift Gift { get; set; }
    }
}
