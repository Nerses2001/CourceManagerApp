using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Entity.EntityConfiguration
{
    public class CustomIdentityUserConfiguration : IEntityTypeConfiguration<CustomIdentityUser>
    {
        public void Configure(EntityTypeBuilder<CustomIdentityUser> builder)
        {
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100)  // Adjust the maximum length as needed
                .HasColumnName("FirstName")
                .HasMaxLength(3);


            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100) // Adjust the maximum length as needed
                .HasColumnName("LastName")
                .HasMaxLength(3);

            builder.Property(u => u.DateOfBirth)
                .IsRequired()
                .HasColumnName("DateOfBirth")
                .HasColumnType("date")
                .HasConversion(
                v => v.ToString("MM/dd/yyyy"),
                v => DateTime.ParseExact(v, "MM/dd/yyyy", null));


            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100) // Adjust the maximum length as needed
                .HasColumnName("Email")
                .HasColumnType("nvarchar(100)")
                .HasConversion(email => email!.ToLower(), email => email.ToLower());

            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20) // Adjust the maximum length as needed
                .HasColumnName("PhoneNumber")
                .HasColumnType("nvarchar(20)")
                 .HasConversion(
                v => Regex.Replace(v ?? "", @"\D", ""),
                v => !string.IsNullOrEmpty(v) ? string.Format("{0:(###) ###-####}",
                double.Parse(v))
                : string.Empty);


            builder.Ignore(u => u.FullName);

            builder.Property(u => u.Address)
                .IsRequired()
                .HasMaxLength(200) // Adjust the maximum length as needed
                .HasColumnName("Address")
                .HasColumnType("nvarchar(200)")
                .HasConversion(
                v => FormatAddress(v),
                v => v);

            builder.Property(u => u.ZipCode)
                .IsRequired()
                .HasMaxLength(20) // Adjust the maximum length as needed
                .HasColumnName("ZipCode")
                .HasColumnType("nvarchar(20)");

        }

        private static string FormatAddress(string input)
        {
            // Replace a (.) period with a space
            input = input.Replace(".", " ");

            // Never enter two consecutive spaces
            input = Regex.Replace(input, @"\s+", " ");

            // Plurals for apartment, avenue, road, street
            input = Regex.Replace(input, @"\bAPT\b", "APTS", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"\bAVE\b", "AVES", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"\bRD\b", "RDS", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"\bST\b", "STS", RegexOptions.IgnoreCase);

            return input;
        }
    }
}
