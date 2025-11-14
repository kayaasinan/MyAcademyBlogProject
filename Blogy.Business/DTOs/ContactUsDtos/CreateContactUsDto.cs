namespace Blogy.Business.DTOs.ContactUsDtos
{
    public class CreateContactUsDto
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
