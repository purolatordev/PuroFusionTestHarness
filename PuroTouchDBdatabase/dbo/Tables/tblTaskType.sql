CREATE TABLE [dbo].[tblTaskType] (
    [idTaskType]        INT           IDENTITY (1, 1) NOT NULL,
    [TaskType]          VARCHAR (100) NULL,
    [UpdatedBy]         VARCHAR (100) NULL,
    [UpdatedOn]         DATETIME      NULL,
    [CreatedBy]         VARCHAR (100) NULL,
    [CreatedOn]         DATETIME      NULL,
    [ActiveFlag]        BIT           NULL,
    [idOnboardingPhase] INT           NULL,
    CONSTRAINT [PK_tblTaskType] PRIMARY KEY CLUSTERED ([idTaskType] ASC)
);

