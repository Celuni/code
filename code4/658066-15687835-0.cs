        [Table("webpages_Membership")]
        public class Membership
        {
            public Membership()
            {
                Roles = new List<Role>();
                OAuthMemberships = new List<OAuthMembership>();
            }
            [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int UserId { get; set; }
            public DateTime? CreateDate { get; set; }
            [StringLength(128)]
            public string ConfirmationToken { get; set; }
            public bool? IsConfirmed { get; set; }
            public DateTime? LastPasswordFailureDate { get; set; }
            public int PasswordFailuresSinceLastSuccess { get; set; }
            [Required, StringLength(128)]
            public string Password { get; set; }
            public DateTime? PasswordChangedDate { get; set; }
            [Required, StringLength(128)]
            public string PasswordSalt { get; set; }
            [StringLength(128)]
            public string PasswordVerificationToken { get; set; }
            public DateTime? PasswordVerificationTokenExpirationDate { get; set; }
            public ICollection<Role> Roles { get; set; }
            [ForeignKey("UserId")]
            public ICollection<OAuthMembership> OAuthMemberships { get; set; }
        }
    Basically just model the fields in the table. This should cover everything, but things may have changed or different constraints may have been added. The `[Table("webpages_Membership")]` tells EF what table to look up in since the name or the class is not an exact match.
