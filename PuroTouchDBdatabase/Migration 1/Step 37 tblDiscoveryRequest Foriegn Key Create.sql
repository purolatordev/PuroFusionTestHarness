--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
USE [PuroTouchDBv3]
GO



IF OBJECT_ID(N'dbo.tblOnboardingPhase', N'U') IS NOT NULL
begin
	print 'Exists -- tblOnboardingPhase table'
	IF OBJECT_ID('dbo.[FK_idOnBPh_OnboardPhase]') IS NOT NULL 
	begin
		print 'Exists -- So drop FK_idOnBPh_OnboardPhase CONSTRAINT'
		ALTER TABLE [dbo].[tblDiscoveryRequest]
			DROP CONSTRAINT [FK_idOnBPh_OnboardPhase]
	end
end

ALTER TABLE [dbo].[tblDiscoveryRequest]  WITH CHECK ADD  CONSTRAINT [FK_idOnBPh_OnboardPhase] FOREIGN KEY([idOnboardingPhase])
REFERENCES [dbo].[tblOnboardingPhase] ([idOnboardingPhase])
GO

IF OBJECT_ID(N'dbo.tblOnboardingPhase', N'U') IS NOT NULL
begin
	print 'Exists -- tblOnboardingPhase table'
	IF OBJECT_ID('dbo.[FK_idEDIOnboard_Disc_EDIOnB]') IS NOT NULL 
	begin
		print 'Exists -- So drop FK_idEDIOnboard_Disc_EDIOnB CONSTRAINT'
		ALTER TABLE [dbo].[tblDiscoveryRequest]
			DROP CONSTRAINT [FK_idEDIOnboard_Disc_EDIOnB]
	end
end
go

ALTER TABLE [dbo].[tblDiscoveryRequest] WITH CHECK ADD  CONSTRAINT [FK_idEDIOnboard_Disc_EDIOnB] FOREIGN KEY([idEDIOnboardingPhase])
REFERENCES [dbo].[tblEDIOnboardingPhase]  ([idEDIOnboardingPhase])
GO



