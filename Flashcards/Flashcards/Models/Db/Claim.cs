using System;

namespace flashcards.Models.Db
{
    public class ClaimDb
    {
        public Guid Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
