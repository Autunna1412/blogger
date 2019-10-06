IF NOT EXISTS
(
	SELECT [name]
	FROM sys.sequences
	WHERE [name] = 'SequenceCatagogyNumber'
)
BEGIN
	CREATE SEQUENCE [DBO].SequenceCatagogyNumber AS INT
	START WITH 1
	INCREMENT BY 1
END

GO
