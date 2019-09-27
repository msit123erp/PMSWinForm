CREATE TABLE [dbo].[PartUnit] (
    [PartUnitOID]  INT          IDENTITY (1, 1) NOT NULL,
    [PartUnitName] NVARCHAR (6) NOT NULL,
    CONSTRAINT [PK_PartUnit] PRIMARY KEY CLUSTERED ([PartUnitOID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'料件單位', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PartUnit';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'單位識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PartUnit', @level2type = N'COLUMN', @level2name = N'PartUnitOID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'單位名稱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PartUnit', @level2type = N'COLUMN', @level2name = N'PartUnitName';

