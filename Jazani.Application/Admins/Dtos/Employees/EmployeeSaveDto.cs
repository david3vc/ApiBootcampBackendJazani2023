namespace Jazani.Application.Admins.Dtos.Employees
{
    public class EmployeeSaveDto
    {
        public int Id { get; set; } // en tabla de bd no es un valor autoincremental
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
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; }
    }
}
