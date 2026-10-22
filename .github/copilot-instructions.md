# GitHub Copilot Instructions for Display Cases (Continued)

## Mod Overview and Purpose

**Mod Name:** Display Cases (Continued)  
**Author:** Cali  
**PackageId:** Mlie.DisplayCases  

Display Cases (Continued) is a RimWorld mod that enhances the aesthetic appeal of legendary items within the game by allowing them to be showcased in specially designed display cases. While legendary items typically possess negative beauty values, this mod conceals those negative attributes and contributes additional beauty through the display cases themselves. These unique furniture pieces can be located under the 'furniture' tab in-game and serve to both preserve and highlight your colony's most prized possessions.

## Key Features and Systems

- **Showcasing Legendary Items**: This mod introduces display cases that allow players to showcase legendary items effectively, adjusting the item's natural beauty to a more favorable level.
- **Added Beauty**: The primary function of the display case is to add beauty to the colony environment, thus enhancing both morale and visual aesthetics.
- **Furniture Integration**: Display cases blend seamlessly with other furniture items, allowing for a consistent and themed environment.

## Coding Patterns and Conventions

- **Consistent Naming**: Classes and members are named clearly to indicate their function and relationship to the rest of the mod, following C# conventions. For example, `Building_Display_Case` and `CompSecondLayer`.
- **DRY Principle**: The mod code avoids repetition, utilizing utility classes like `SaveStorageSettingsGizmoUtil` to handle common functions.
- **Use of Properties**: Properties like `Altitude` and `Props` are used for manageability and encapsulation of class data.

## XML Integration

- **XML Defs**: The mod uses XML files to define custom building attributes. Key definitions are located in:
  - `DisplayCases_Building.xml`: Contains `ThingDef` elements to configure the display case items.
- **Localization Support**: The mod supports translations through XML templates found in `TranslationTemplate`.

## Harmony Patching

- **Harmony**: This mod does not directly showcase Harmony patches, but modification of game logic through Harmony can be considered for future extensions or complex game logic alterations.
  
## Suggestions for Copilot

1. **Code Documentation**: Ensure all public methods have XML comments to improve readability and assist copilot in suggesting accurate code completions.
2. **Error-Handling**: Implement robust error-handling strategies, especially for mod loading and interactions, to guide copilot in producing exception-safe code.
3. **Extend Use of LINQ**: Using LINQ can simplify and enhance data manipulation. Guide copilot by including more LINQ examples in existing code.
4. **Event-Driven Design**: Consider expanding to event-driven designs where appropriate, to simplify logic and improve copilot's ability to suggest real-time reactions to game events.
5. **Multi-File Navigation**: Ensure each file cohesively connects with others to allow copilot to effectively navigate class and method interactions.

Consistently apply these principles and conventions across your mod development to enhance both your workflow and the suggestions provided by GitHub Copilot.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

