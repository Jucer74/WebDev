DROP TABLE Concepts; 
CREATE TABLE Concepts (
  Id int IDENTITY(1,1) NOT NULL,
  Pxordx varchar(5),
  Oldpxordx varchar(5),	
  CodeType varchar(20),	
  Concept_Class_Id varchar(100),
  Concept_Id int NULL,	
  Vocabulary_Id varchar(100),	
  Domain_Id varchar(100),	
  Track varchar(100),	
  Standard_Concept varchar(20),	
  Code varchar(10) NOT NULL,	
  CodeWithPeriods varchar(20),	
  CodeScheme varchar(20),	
  Long_Desc text,	
  Short_Desc varchar(255),	
  Code_Status varchar(5),	
  Code_Change varchar(20),	
  Code_Change_Year int,
  Code_Planned_Type varchar(5),	
  Code_Billing_Status varchar(5),	
  Code_Cms_Claim_Status varchar(5),	
  Sex_Cd varchar(5),
  Anat_Or_Cond varchar(20),	
  Poa_Code_Status varchar(100),	
  Poa_Code_Change varchar(20),	
  Poa_Code_Change_Year varchar(100),	
  Valid_Start_Date varchar(20),
  Valid_End_Date varchar(20),	
  Invalid_Reason varchar(5),	
  Create_Dt int,
CONSTRAINT [PK_Concepts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]