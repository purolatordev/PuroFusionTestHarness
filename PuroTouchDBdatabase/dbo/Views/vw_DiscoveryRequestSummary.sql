
CREATE VIEW [dbo].[vw_DiscoveryRequestSummary]
AS
SELECT        dbo.tblDiscoveryRequest.idRequest, dbo.tblDiscoveryRequest.isNewRequest, dbo.tblRequestTypes.RequestType, dbo.tblVendorType.VendorType, dbo.tblDiscoveryRequest.SalesRepName, 
                         dbo.tblDiscoveryRequest.SalesRepEmail, dbo.tblDiscoveryRequest.idOnboardingPhase, dbo.tblDiscoveryRequest.District, dbo.tblDiscoveryRequest.CustomerName, dbo.tblDiscoveryRequest.Address, 
                         dbo.tblDiscoveryRequest.City, dbo.tblDiscoveryRequest.State, dbo.tblDiscoveryRequest.Zipcode, dbo.tblDiscoveryRequest.Country, dbo.tblDiscoveryRequest.Commodity, dbo.tblDiscoveryRequest.ProjectedRevenue, 
                         dbo.tblDiscoveryRequest.CurrentSolution, 
                         dbo.tblDiscoveryRequest.ProposedCustoms, dbo.tblDiscoveryRequest.CallDate1, dbo.tblDiscoveryRequest.CallDate2, dbo.tblDiscoveryRequest.CallDate3, dbo.tblDiscoveryRequest.UpdatedBy, 
                         dbo.tblDiscoveryRequest.UpdatedOn, dbo.tblDiscoveryRequest.CreatedBy, dbo.tblDiscoveryRequest.CreatedOn, dbo.tblDiscoveryRequest.ActiveFlag, dbo.tblDiscoveryRequest.CurrentGoLive, 
                         dbo.tblDiscoveryRequest.TargetGoLive, dbo.tblDiscoveryRequest.ActualGoLive, dbo.tblDiscoveryRequest.worldpakFlag, SUM(dbo.tblDiscoveryRequestNotes.timeSpent) AS TotalMinutes, CONVERT(varchar, 
                         FLOOR(SUM(dbo.tblDiscoveryRequestNotes.timeSpent) / 60.0)) + ':' + RIGHT('0' + CONVERT(varchar, SUM(dbo.tblDiscoveryRequestNotes.timeSpent) % 60), 2) AS TotalTimeSpent, dbo.tblOnboardingPhase.OnboardingPhase, 
                         dbo.tblDiscoveryRequest.idITBA, dbo.vw_ITBA.ITBA, dbo.vw_ITBA.ActiveDirectoryName, dbo.tblShippingChannel.ShippingChannel, dbo.tblThirdPartyVendor.VendorName
FROM            dbo.tblDiscoveryRequest LEFT OUTER JOIN
                         dbo.tblDiscoveryRequestNotes ON dbo.tblDiscoveryRequest.idRequest = dbo.tblDiscoveryRequestNotes.idRequest LEFT OUTER JOIN
                         dbo.tblOnboardingPhase ON dbo.tblDiscoveryRequest.idOnboardingPhase = dbo.tblOnboardingPhase.idOnboardingPhase LEFT OUTER JOIN
                         dbo.vw_ITBA ON dbo.tblDiscoveryRequest.idITBA = dbo.vw_ITBA.idITBA LEFT OUTER JOIN
                         dbo.tblShippingChannel ON dbo.tblDiscoveryRequest.idShippingChannel = dbo.tblShippingChannel.idShippingChannel LEFT OUTER JOIN
                         dbo.tblRequestTypes ON dbo.tblDiscoveryRequest.idRequestType = dbo.tblRequestTypes.idRequestType LEFT OUTER JOIN
                         dbo.tblVendorType ON dbo.tblDiscoveryRequest.idVendorType = dbo.tblVendorType.idVendorType LEFT OUTER JOIN
                         dbo.tblThirdPartyVendor ON dbo.tblDiscoveryRequest.idVendor = dbo.tblThirdPartyVendor.idThirdPartyVendor
GROUP BY dbo.tblDiscoveryRequest.idRequest, dbo.tblDiscoveryRequest.isNewRequest, dbo.tblRequestTypes.RequestType, dbo.tblVendorType.VendorType, dbo.tblDiscoveryRequest.SalesRepName, 
                         dbo.tblDiscoveryRequest.SalesRepEmail, dbo.tblDiscoveryRequest.idOnboardingPhase, dbo.tblDiscoveryRequest.District, dbo.tblDiscoveryRequest.CustomerName, dbo.tblDiscoveryRequest.Address, 
                         dbo.tblDiscoveryRequest.City, dbo.tblDiscoveryRequest.State, dbo.tblDiscoveryRequest.Zipcode, dbo.tblDiscoveryRequest.Country, dbo.tblDiscoveryRequest.Commodity, dbo.tblDiscoveryRequest.ProjectedRevenue, 
                         dbo.tblDiscoveryRequest.CurrentSolution, 
                         dbo.tblDiscoveryRequest.ProposedCustoms, dbo.tblDiscoveryRequest.CallDate1, dbo.tblDiscoveryRequest.CallDate2, dbo.tblDiscoveryRequest.CallDate3, dbo.tblDiscoveryRequest.UpdatedBy, 
                         dbo.tblDiscoveryRequest.UpdatedOn, dbo.tblDiscoveryRequest.CreatedBy, dbo.tblDiscoveryRequest.CreatedOn, dbo.tblDiscoveryRequest.ActiveFlag, dbo.tblDiscoveryRequest.CurrentGoLive, 
                         dbo.tblDiscoveryRequest.TargetGoLive, dbo.tblDiscoveryRequest.ActualGoLive, dbo.tblDiscoveryRequest.worldpakFlag, dbo.tblOnboardingPhase.OnboardingPhase, dbo.tblDiscoveryRequest.idITBA, dbo.vw_ITBA.ITBA, 
                         dbo.vw_ITBA.ActiveDirectoryName, dbo.tblShippingChannel.ShippingChannel, dbo.tblThirdPartyVendor.VendorName

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[42] 4[11] 2[24] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblDiscoveryRequest"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 270
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblDiscoveryRequestNotes"
            Begin Extent = 
               Top = 6
               Left = 308
               Bottom = 135
               Right = 494
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblOnboardingPhase"
            Begin Extent = 
               Top = 6
               Left = 532
               Bottom = 135
               Right = 742
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "vw_ITBA"
            Begin Extent = 
               Top = 6
               Left = 780
               Bottom = 135
               Right = 998
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblShippingChannel"
            Begin Extent = 
               Top = 6
               Left = 1036
               Bottom = 135
               Right = 1242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblRequestTypes"
            Begin Extent = 
               Top = 6
               Left = 1280
               Bottom = 135
               Right = 1466
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblVendorType"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 267
              ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_DiscoveryRequestSummary';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' Right = 224
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblThirdPartyVendor"
            Begin Extent = 
               Top = 138
               Left = 262
               Bottom = 268
               Right = 470
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_DiscoveryRequestSummary';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_DiscoveryRequestSummary';

