IF NOT EXISTS
(
	SELECT [name]
	FROM sys.sequences
	WHERE [name] = 'SequenceHashtagNumber'
)
BEGIN
	CREATE SEQUENCE [DBO].SequenceHashtagNumber AS INT
	START WITH 1
	INCREMENT BY 1
END

GO
