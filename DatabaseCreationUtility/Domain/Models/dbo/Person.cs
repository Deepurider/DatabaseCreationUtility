using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Domain.Models.dboSchema;


namespace Domain.Models.dboSchema;

[Table("Person")]
public partial class Person
{
    [Key]
    public int PersonId { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [StringLength(12)]
    public string? PhoneNumber { get; set; }

    [StringLength(50)]
    public string? City { get; set; }

    public bool? Deleted { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    [InverseProperty("Person")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}

