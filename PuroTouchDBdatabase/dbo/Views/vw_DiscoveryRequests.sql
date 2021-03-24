
CREATE VIEW [dbo].[vw_DiscoveryRequests]
AS
SELECT        dbo.tblDiscoveryRequest.idRequest, dbo.tblDiscoveryRequest.isNewRequest, dbo.tblRequestTypes.RequestType, dbo.tblDiscoveryRequest.SalesRepName, 
                         dbo.tblDiscoveryRequest.SalesRepEmail, dbo.tblDiscoveryRequest.idOnboardingPhase, dbo.tblDiscoveryRequest.District, 
                         dbo.tblDiscoveryRequest.CustomerName, dbo.tblDiscoveryRequest.Address, dbo.tblDiscoveryRequest.City, dbo.tblDiscoveryRequest.State, 
                         dbo.tblDiscoveryRequest.Zipcode, dbo.tblDiscoveryRequest.Country, dbo.tblDiscoveryRequest.Commodity, dbo.tblDiscoveryRequest.ProjectedRevenue, 
                         dbo.tblDiscoveryRequest.CurrentSolution, 
                         dbo.tblDiscoveryRequest.ProposedCustoms, dbo.tblDiscoveryRequest.CallDate1, dbo.tblDiscoveryRequest.CallDate2, dbo.tblDiscoveryRequest.CallDate3, 
                         dbo.tblDiscoveryRequest.UpdatedBy, dbo.tblDiscoveryRequest.UpdatedOn, dbo.tblDiscoveryRequest.CreatedBy, dbo.tblDiscoveryRequest.CreatedOn, 
                         dbo.tblDiscoveryRequest.ActiveFlag, dbo.tblDiscoveryRequestNotes.idNote, dbo.tblDiscoveryRequestNotes.idTaskType, dbo.tblDiscoveryRequestNotes.noteDate, 
                         dbo.tblDiscoveryRequestNotes.timeSpent, dbo.tblDiscoveryRequestNotes.publicNote, dbo.tblDiscoveryRequestNotes.privateNote, 
                         dbo.tblDiscoveryRequestServices.idRequestSvc, dbo.tblDiscoveryRequestServices.idShippingSvc, dbo.tblDiscoveryRequestServices.volume, 
                         dbo.tblTaskType.TaskType, dbo.tblShippingServices.serviceDesc, dbo.tblOnboardingPhase.OnboardingPhase, dbo.tblOnboardingPhase.SortValue
FROM            dbo.tblDiscoveryRequest INNER JOIN
                         dbo.tblDiscoveryRequestNotes ON dbo.tblDiscoveryRequest.idRequest = dbo.tblDiscoveryRequestNotes.idRequest INNER JOIN
                         dbo.tblDiscoveryRequestServices ON dbo.tblDiscoveryRequest.idRequest = dbo.tblDiscoveryRequestServices.idRequest INNER JOIN
                         dbo.tblTaskType ON dbo.tblDiscoveryRequestNotes.idTaskType = dbo.tblTaskType.idTaskType INNER JOIN
                         dbo.tblShippingServices ON dbo.tblDiscoveryRequestServices.idShippingSvc = dbo.tblShippingServices.idShippingSvc INNER JOIN
                         dbo.tblOnboardingPhase ON dbo.tblDiscoveryRequest.idOnboardingPhase = dbo.tblOnboardingPhase.idOnboardingPhase LEFT OUTER JOIN
                         dbo.tblRequestTypes ON dbo.tblDiscoveryRequest.idRequestType = dbo.tblRequestTypes.idRequestType

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[25] 4[20] 2[37] 3) )"
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
         Top = -1248
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblDiscoveryRequest"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 240
            End
            DisplayFlags = 280
            TopColumn = 28
         End
         Begin Table = "tblDiscoveryRequestNotes"
            Begin Extent = 
               Top = 32
               Left = 279
               Bottom = 170
               Right = 491
            End
            DisplayFlags = 280
            TopColumn = 8
         End
         Begin Table = "tblDiscoveryRequestServices"
            Begin Extent = 
               Top = 25
               Left = 523
               Bottom = 154
               Right = 693
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "tblTaskType"
            Begin Extent = 
               Top = 138
               Left = 682
               Bottom = 267
               Right = 852
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "tblShippingServices"
            Begin Extent = 
               Top = 240
               Left = 489
               Bottom = 369
               Right = 659
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblOnboardingPhase"
            Begin Extent = 
               Top = 213
               Left = 136
               Bottom = 342
               Right = 330
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblRequestTypes"
            Begin Extent = 
               Top = 1254
               Left = 38
              ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_DiscoveryRequests';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' Bottom = 1383
               Right = 208
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
      Begin ColumnWidths = 45
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
      Begin ColumnWidths = 11
         Column = 2055
         Alias = 2550
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_DiscoveryRequests';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_DiscoveryRequests';

