CREATE TABLE [dbo].[tblThirdPartyVendor] (
    [idThirdPartyVendor] INT           IDENTITY (1, 1) NOT NULL,
    [VendorName]         VARCHAR (100) NULL,
    [UpdatedBy]          VARCHAR (100) NULL,
    [UpdatedOn]          DATETIME      NULL,
    [CreatedBy]          VARCHAR (100) NULL,
    [CreatedOn]          DATETIME      NULL,
    [ActiveFlag]         BIT           NULL,
    CONSTRAINT [PK_tblThirdPartyVendor] PRIMARY KEY CLUSTERED ([idThirdPartyVendor] ASC)
);

