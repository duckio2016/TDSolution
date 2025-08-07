using System.ComponentModel.DataAnnotations;

namespace TDSolution.DTOs
{
    public class CustomerDto
    {
        public CustomerDto()
        {
            FullName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
        }

        [MinLength(6)]
        public string FullName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; set; }

        [RegularExpression(@"^(0|\+84)(3[2-9]|5[6|8|9]|7[0|6-9]|8[1-5]|9[0-9])[0-9]{7}$")]
        public string PhoneNumber { get; set; }
    }

    public class CustomerDetailDto : CustomerDto
    {
        public int CustomerID { get; set; }
    }
}