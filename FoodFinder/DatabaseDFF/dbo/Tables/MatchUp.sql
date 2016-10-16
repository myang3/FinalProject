CREATE TABLE [dbo].[MatchUp] (
    [MatchID]    INT IDENTITY (1, 1) NOT NULL,
    [DonationID] INT NOT NULL,
    [ReceiverID] INT NOT NULL,
    CONSTRAINT [PK_MatchUp] PRIMARY KEY CLUSTERED ([MatchID] ASC),
    CONSTRAINT [FK_MatchUp_DonationData] FOREIGN KEY ([DonationID]) REFERENCES [dbo].[DonationData] ([DonationID]),
    CONSTRAINT [FK_MatchUp_ReceiverData] FOREIGN KEY ([ReceiverID]) REFERENCES [dbo].[ReceiverData] ([ReceiverID])
);

