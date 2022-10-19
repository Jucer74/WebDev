using System.ComponentModel.DataAnnotations;

namespace WebDev.Api.Model
{
  public class Concept
  {
    [Key]
    [Required]
    public int Id { get; set; }

    [MaxLength(5)]
    public string Pxordx { get; set; }

    [MaxLength(5)]
    public string Oldpxordx { get; set; }

    [MaxLength(20)]
    public string CodeType { get; set; }

    [MaxLength(100)]
    public string Concept_Class_Id { get; set; }

    public int Concept_Id { get; set; }

    [MaxLength(100)]
    public string Vocabulary_Id { get; set; }

    [MaxLength(100)]
    public string Domain_Id { get; set; }

    [MaxLength(100)]
    public string Track { get; set; }

    [MaxLength(20)]
    public string Standard_Concept { get; set; }

    [Required]
    [MaxLength(10)]
    public string Code { get; set; }

    [MaxLength(20)]
    public string CodeWithPeriods { get; set; }

    [MaxLength(20)]
    public string CodeScheme { get; set; }

    public string Long_Desc { get; set; }

    [MaxLength(255)]
    public string Short_Desc { get; set; }

    [MaxLength(5)]
    public string Code_Status { get; set; }

    [MaxLength(20)]
    public string Code_Change { get; set; }

    public int Code_Change_Year { get; set; }

    [MaxLength(5)]
    public string Code_Planned_Type { get; set; }

    [MaxLength(5)]
    public string Code_Billing_Status { get; set; }

    [MaxLength(5)]
    public string Code_Cms_Claim_Status { get; set; }

    [MaxLength(5)]
    public string Sex_Cd { get; set; }

    [MaxLength(20)]
    public string Anat_Or_Cond { get; set; }

    [MaxLength(100)]
    public string Poa_Code_Status { get; set; }

    [MaxLength(20)]
    public string Poa_Code_Change { get; set; }

    [MaxLength(100)]
    public string Poa_Code_Change_Year { get; set; }

    [MaxLength(20)]
    public string Valid_Start_Date { get; set; }

    [MaxLength(20)]
    public string Valid_End_Date { get; set; }

    [MaxLength(5)]
    public string Invalid_Reason { get; set; }

    public int Create_Dt { get; set; }
  }
}