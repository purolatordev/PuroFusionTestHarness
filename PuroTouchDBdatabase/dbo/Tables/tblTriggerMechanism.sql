CREATE TABLE [dbo].[tblTriggerMechanism] (
    [idTriggerMechanism] INT           IDENTITY (1, 1) NOT NULL,
    [TriggerMechanism]   VARCHAR (100) NULL,
    [UpdatedBy]          VARCHAR (100) NULL,
    [UpdatedOn]          DATETIME      NULL,
    [CreatedBy]          VARCHAR (100) NULL,
    [CreatedOn]          DATETIME      NULL,
    [ActiveFlag]         BIT           NULL,
    CONSTRAINT [PK_tblTriggerMechanism] PRIMARY KEY CLUSTERED ([idTriggerMechanism] ASC)
);

