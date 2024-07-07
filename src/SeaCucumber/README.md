# README

This is an attempt to solve the puzzle from day 25 of year 2011 of [advent of code](https://adventofcode.com/2021/day/25)

## Goal of the puzzle

The goal of the puzzle is to find a safe location for the submarine to land.
What is the first step on which no cucumbers move?

## What is given

- east-facing sea cucumbers only moves east
- south-facing sea cucumbers only moves south
- every step, the sea cucumbers attempt to move and can only do so onto an empty location
- every sea cucumbers in a herd are moving simultaneously (a herd contain every sea cucumber facing the same direction)
- every step, the east-facing sea cucumbers are moving first and then the south-facing cucumbers
- due to strong water currents, sea cucumbers that move off the right edge of the map appears on the left edge, and the ones that move of the bottom edge of the map appear on the top edge
- Sea cucumbers always check whether their destination location is empty before moving, even if that is on the opposite side of the map 

## Initial thought on how to solve the puzzle

There will be a map representing empty locations or locations with sea cucumbers on it.
This is not a simple puzzle to solve, so I need to break this into smaller pieces.

The map can be represented as a 2d grid.
A location is either empty, or has a east- or south-facing sea cucumber.
Need to parse given input as a 2d grid.


## Tests

I will include some tests, where the main purpose of this, is to verify that my code is working correctly against the example of the puzzle.
In the given example the sea cucumbers stopped moving after 58 steps.