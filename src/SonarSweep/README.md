# README

This is an attempt to solve the puzzle from day 1 of year 2021 of [advent of code](https://adventofcode.com/2021/day/1).

## Goal of the puzzle

The goal of the puzzle is to count the number of measurements that are larger than the previous measurement.

## Initial thoughts on how to solve the puzzle

A report is a series of numbers separated by a newline.
So I need to read the report file line by line.

The line just read, that is the current measurement.
The first measurement has no previous measurement, so that one should not be included.

Compare each current with the previous measurement until the end of the report and report back how many increases are counted.

## Tests

I will include some tests, where the main purpose of this, is to verify that my code is working correctly against the example of the puzzle.
It is given that the example report should return 7 increases.