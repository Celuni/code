    using Microsoft.Bot.Builder.Teams;
    using Microsoft.Bot.Schema.Teams;
    using Microsoft.Bot.Connector.Teams;
    ...
    ConversationList channels = await teamsContext.Operations.FetchChannelListAsync(incomingTeamId);
    
    TeamDetails teamInfo = await teamsContext.Operations.FetchTeamDetailsAsync(incomingTeamId);
