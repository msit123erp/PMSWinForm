CREATE TABLE [dbo].[SourceList] (
    [SourceListOID]     INT            IDENTITY (1, 1) NOT NULL,
    [PartNumber]        NVARCHAR (10)  NOT NULL,
    [Batch]             INT            NOT NULL,
    [Discount]          DECIMAL (3, 2) NOT NULL,
    [DiscountBeginDate] DATETIME       NULL,
    [DiscountEndDate]   DATETIME       NULL,
    [CreateDate]        DATETIME       NULL,
    CONSTRAINT [PK_SourceList] PRIMARY KEY CLUSTERED ([SourceListOID] ASC),
    CONSTRAINT [FK_SourceList_Part] FOREIGN KEY ([PartNumber]) REFERENCES [dbo].[Part] ([PartNumber])
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'貨源清單', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SourceList';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'貨源清單識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SourceList', @level2type = N'COLUMN', @level2name = N'SourceListOID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'料件編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SourceList', @level2type = N'COLUMN', @level2name = N'PartNumber';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'批量', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SourceList', @level2type = N'COLUMN', @level2name = N'Batch';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'折扣', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SourceList', @level2type = N'COLUMN', @level2name = N'Discount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'折扣開始時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SourceList', @level2type = N'COLUMN', @level2name = N'DiscountBeginDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'折扣結束時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SourceList', @level2type = N'COLUMN', @level2name = N'DiscountEndDate';

