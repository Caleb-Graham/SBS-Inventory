SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('dbo.Inventory') IS NULL
BEGIN
    BEGIN
        CREATE TABLE [dbo].[Inventory]( 
            [InventoryItemID] [int] IDENTITY(1,1) NOT NULL,
            [InventoryItemName] [varchar](255) NOT NULL,
            [Count] [int] NOT NULL,
            [Price] [money] NULL,
    --     PRIMARY KEY CLUSTERED
    --     (
    --         [TemplateID] ASC
    --     )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
    --         PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
    --     ) ON [PRIMARY]
    --     WITH
    --     (
         --  SYSTEM_VERSIONING = ON ( HISTORY_TABLE = [dbo].[Templates_History] )
        )
    -- END
    -- BEGIN
    --     ALTER TABLE [dbo].[Templates] ADD  DEFAULT (getutcdate()) FOR [SysStartTime]
    -- END
    -- BEGIN
    --     ALTER TABLE [dbo].[Templates] ADD  DEFAULT (CONVERT([datetime2],'9999-12-31 23:59:59.9999999')) FOR [SysEndTime]
    -- END
    --     BEGIN
    --     ALTER TABLE [dbo].[Templates]  WITH CHECK ADD CONSTRAINT [FK_Templates_TemplateStatuses] FOREIGN KEY([TemplateStatusID])
    --     REFERENCES [dbo].[Statuses] ([StatusID])
    -- END
    -- BEGIN
    --     ALTER TABLE [dbo].[Templates]  WITH CHECK ADD CONSTRAINT [FK_Templates_LastUpdateUserID] FOREIGN KEY([LastUpdateUserID])
    --     REFERENCES [dbo].[Users] ([UserID])
     END
END
GO