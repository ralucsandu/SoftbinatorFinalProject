namespace FinalProject.Entities
{
    public class Gift
    {
        public int Id { get; set; }

        public ICollection<Obiect> Obiects { get; set; }
        public ICollection<StudentGift> StudentsGifts { get; set; }

    }
}
