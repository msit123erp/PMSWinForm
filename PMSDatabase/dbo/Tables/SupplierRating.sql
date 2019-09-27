CREATE TABLE [dbo].[SupplierRating] (
    [SupplierRatingOID] INT          IDENTITY (1, 1) NOT NULL,
    [RatingName]        NVARCHAR (6) NOT NULL,
    CONSTRAINT [PK_SupplierRating] PRIMARY KEY CLUSTERED ([SupplierRatingOID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'供應商等級', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierRating';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'供應商等級識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierRating', @level2type = N'COLUMN', @level2name = N'SupplierRatingOID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'等級名稱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierRating', @level2type = N'COLUMN', @level2name = N'RatingName';

