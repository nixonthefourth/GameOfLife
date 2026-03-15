# Conway's Game of Life — C#

A clean, minimal implementation of **Conway's Game of Life** built with C# and .NET Core. The simulation runs on a 4×4 grid, bringing the classic zero-player cellular automaton to life in your terminal.

---

## About the Game

Conway's Game of Life, devised by mathematician John Horton Conway in 1970, is a **cellular automaton** that simulates the birth, survival, and death of cells on a grid — based on just four simple rules:

| Rule | Condition |
|---|---|
| **Underpopulation** | A live cell with fewer than 2 live neighbours dies |
| **Survival** | A live cell with 2 or 3 live neighbours lives on |
| **Overpopulation** | A live cell with more than 3 live neighbours dies |
| **Reproduction** | A dead cell with exactly 3 live neighbours becomes alive |

Despite their simplicity, these rules produce surprisingly complex and beautiful patterns.

---

## File Structure

```
GameOfLife/
├── GameOfLife/
│   ├── BoardInteraction.cs   # Grid rendering and cell state logic
│   ├── Program.cs            # Entry point and simulation loop
│   └── GameOfLife.csproj     # .NET project configuration
├── GameOfLife.sln            # Visual Studio solution file
├── .gitignore
└── README.md
```

---

## Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) (any recent version)

### Run the simulation

```bash
git clone https://github.com/nixonthefourth/GameOfLife.git
cd GameOfLife
dotnet run --project GameOfLife
```

---

## How It Works

- **`Program.cs`** — Initialises the board, seeds the starting configuration, and drives the generation loop.
- **`BoardInteraction.cs`** — Handles the core logic: counting neighbours, applying the four rules each tick, and printing the grid to the console.

Each generation, the board state is evaluated simultaneously for all cells and the next state is computed from the current one — true to Conway's original design.

---

## Grid

The simulation uses a fixed **4×4 grid**, making it easy to trace state transitions by hand and verify the rules are working correctly.

```
. # . .
. # . .
. # . .
. . . .
```
*Example: a "blinker" oscillator*

---

## Built With

- **C#** — Core implementation language
- **.NET Core** — Cross-platform runtime

---

## Further Reading

- [Conway's Game of Life — Wikipedia](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life)
- [LifeWiki — pattern encyclopaedia](https://conwaylife.com/wiki/)
