CREATE TABLE [dbo].[tblEDIOnboardingPhase] (
    [idEDIOnboardingPhase]   INT          IDENTITY (1, 1) NOT NULL,
    [EDIOnboardingPhaseType] VARCHAR (50) NULL,
    [UpdatedBy]              VARCHAR (50) NULL,
    [UpdatedOn]              DATETIME     NULL,
    [CreatedBy]              VARCHAR (50) NULL,
    [CreatedOn]              DATETIME     NULL,
    [ActiveFlag]             BIT          NULL,
    CONSTRAINT [PK_tblEDIOnboardingPhase] PRIMARY KEY CLUSTERED ([idEDIOnboardingPhase] ASC)
);

