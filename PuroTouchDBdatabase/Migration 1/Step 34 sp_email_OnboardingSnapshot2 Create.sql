USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
GO

/****** Object:  View [dbo].[vw_EDISpecialist]    Script Date: 8/3/2021 1:35:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_email_OnboardingSnapshot2]

AS
BEGIN

DECLARE @HTML_Header VARCHAR(MAX) ;
	SET @HTML_Header = '<html><style>tr:nth-of-type(even) { background-color:#ccc; } </style><body>';
	DECLARE @HTML_Footer VARCHAR(MAX) ;
	SET @HTML_Footer = '</body></html>'
	DECLARE @HTML_Body VARCHAR(MAX) ;
	EXEC @HTML_Body = sp_email_OnboardingSnapshot_Body;
	print @HTML_Body;

--	DECLARE @HTML_EMAIL VARCHAR(MAX);
--	Set @HTML_EMAIL = @HTML_Header + ISNULL(@HTML_Body,'null') + @HTML_Footer

--	select @HTML_EMAIL

--	DECLARE @subj VARCHAR(50);
--	SET @subj = 'Onboarding Snapshot ' + FORMAT(GETDATE(),'MM/dd/yy');

--IF ( @HTML_EMAIL is not null ) 
--EXEC msdb.dbo.sp_send_dbmail 
--	@profile_name = 'DB Mail',
--	@recipients='Michele.Kennedy@purolator.com',
--	--@recipients='Jim.Kardiasmenos@purolator.com;Allie.Carson@purolator.com;Karen.Arias@purolator.com;Michele.Kennedy@purolator.com',
--    @subject = @subj,
--    @body = @HTML_EMAIL,
--    @body_format = 'HTML';

END
GO






