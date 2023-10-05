namespace Jazani.Domain.Admins.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Maidenname { get; set; }
        public string? PersonalMail { get; set; }
        public string? CorporatEmail { get; set; }
        public string? Landline { get; set; }
        public string? Mobile { get; set; }
        public string? DocumentNumber { get; set; }
        public int? MiningunitId { get; set; }
        public int? NationalityId { get; set; }
        public int? IdentificationDocumentId { get; set; }
        public int? CivilStatusId { get; set; }
        public bool? IsSincronized { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? StartDate { get; set; }
        public bool State { get; set; }

        public virtual IdentificationDocument? IdentificationDocument { get; set; }
        public virtual Nationality? Nationality { get; set; }
    }
}
