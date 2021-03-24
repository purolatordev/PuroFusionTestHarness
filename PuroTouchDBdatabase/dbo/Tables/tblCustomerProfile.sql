CREATE TABLE [dbo].[tblCustomerProfile] (
    [idCustomerProfile]        INT           NULL,
    [CompanyName]              VARCHAR (255) NULL,
    [CompanyWebsite]           VARCHAR (255) NULL,
    [PrimBusinessContact]      VARCHAR (255) NULL,
    [PrimBusinessContactPhone] VARCHAR (255) NULL,
    [PrimBusinessContactEmail] VARCHAR (255) NULL,
    [idProducttypeRel]         INT           NULL,
    [idBillingTyperel]         INT           NULL,
    [idSolutionType]           INT           NULL,
    [elink]                    VARCHAR (50)  NULL,
    [CustomsSupported]         NVARCHAR (50) NULL,
    [Brokername]               VARCHAR (50)  NULL,
    [PASSNo]                   VARCHAR (50)  NULL,
    [PARSNo]                   VARCHAR (50)  NULL,
    [CreatedBy]                VARCHAR (50)  NULL,
    [CreatedDate]              DATETIME      NULL,
    [ModifiedBy]               VARCHAR (50)  NULL,
    [ModifiedDate]             DATETIME      NULL
);

