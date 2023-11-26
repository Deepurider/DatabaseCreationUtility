using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Domain.Models.dboSchema;


namespace Domain.Models.dboSchema;

[Table("Student")]
public partial class Student
{
    [Key]
    public int StudentId { get; set; }

    public int? PersonId { get; set; }

    [StringLength(50)]
    public string? ClassName { get; set; }

    public bool? Deleted { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("Students")]
    public virtual Person? Person { get; set; }
}

