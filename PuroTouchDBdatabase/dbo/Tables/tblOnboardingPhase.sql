CREATE TABLE [dbo].[tblOnboardingPhase] (
    [idOnboardingPhase] INT           IDENTITY (1, 1) NOT NULL,
    [OnboardingPhase]   VARCHAR (100) NULL,
    [UpdatedBy]         VARCHAR (100) NULL,
    [UpdatedOn]         DATETIME      NULL,
    [CreatedBy]         VARCHAR (100) NULL,
    [CreatedOn]         DATETIME      NULL,
    [ActiveFlag]        BIT           NULL,
    [SortValue]         INT           NULL,
    CONSTRAINT [PK_tblOnboardingPhase] PRIMARY KEY CLUSTERED ([idOnboardingPhase] ASC)
);

