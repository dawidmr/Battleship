Battleship Game Simulator

1. Simulator has been created in Blazor WebAssembly.
Why?
- To create environment agnostic solution based on .Net core.
- To avoid using JS.
- To learn Blazor.

2. Projects
a) Client
- BattleShipGame is main component which contains 4 Grid components and 1 GridExplanation. It has Engine implementation injected and calls only this class.
- Grid component is responsible only for printing the grid. 
- The main class here is Engine which doesn’t have complicated logic included. It is just facade for Game project and loading configuration.
- ConfigService – service responsible for retrieving configuration from server side. 
b) Server
- Project used only for accessing configuration.
