Battleship Game Simulator

1. Simulator has been created in Blazor WebAssembly.
	Why?
	- To create environment agnostic solution based on .Net core.
	- To avoid using JS.
	- To learn Blazor.

2. Assumptions 
	- Only vertical ships are created.
	- 2 dimensions board only.
	- Board is a square. 
	- User doesn’t have influence on board size of ships count. Both are stored in configuration. User can only start a simulation.
	- Used algorithms are simple but can be easily replaced.
	- Simulation can be extendend with new rules or game variants.
	
3. Projects
	a) Client
		- BattleShipGame is main component which contains 4 Grid (board) components and 1 GridExplanation. It has Engine implementation injected and calls only this class.
		- Grid component represents board and it is responsible only for printing the grid. 
		- The main class here is Engine which doesn’t have complicated logic included. It is just facade for Game project and loading configuration.
		- ConfigService – service responsible for retrieving configuration from server side. 
	b) Server
		- Project used only for accessing configuration (stored in Configuration/BattleshipConfiguration.json)
	c) Models
		•	SquareStates – all states that can be set. State changes are managed by StateTransition classes.
	d) Game
		•	Player – class creating and keeping information about player’s grids. 
			o	Grids are public so Engine can read them.
			o	Grid creating and targeting algorithms are injected in constructor. Algorithms can be easily replaced with more efficient ones.
			
		•	Grids 
			o	Factories and creator – create grid based on passed grid type. Decides which GridFiller and StateTransition implementation are used. (Another grid type can be easily added here).
			o	Grid – keep ships information redundantly: squares – to easily present grid, ships – to facilitate ships manipulation.
					Calls given StateTransition to change the state. (New state or rule can be easily added).
					Calls given Filling strategy to fill grid with ships. (Filling algorithm can be easily replaced.)
			o	Fillers – different fillers are used for different grids. Empty filler doesn’t do anything as opponent’s grid is initially empty.
			
		•	StateTransitions – set of rules how states can be changed. Defines flow of states of square depending on game rules. 
		•	RandomTargetStrategy – very simple algorithm, mostly random.
	e) Tests
		- Unit tests of most fragile code.