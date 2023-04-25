[![GitHub](https://img.shields.io/github/license/melgrubb/testsfor)](https://opensource.org/licenses/MIT)
[![GitHub issues](https://img.shields.io/github/issues/melgrubb/testsfor)](https://github.com/MelGrubb/TestsFor/issues)
[![CI](https://github.com/MelGrubb/testsfor/actions/workflows/ci.yml/badge.svg)](https://github.com/MelGrubb/TestsFor/actions/workflows/ci.yml)
[![Discord](https://img.shields.io/discord/813785114722697258?logo=discord&logoColor=white)](https://discord.com/channels/813785114722697258/1100247905094340729)

# TestsFor
A simple, lightweight BDD Testing framework, inspired by Matt Honeycutt's SpecsFor library.

## Why?
Why do we need another testing framework? Well, we don't really, but I've always been a big fan of the SpecsFor library. It let me write tests in a way that didn't contort C# into unnatural shapes. There are plenty of BDD style frameworks out there, but they all seem to be written with someone other than programmers in mind.

SpecFlow starts with cucumber files that can theoretically be written by someone on the QA team and then *translated* into code. That sounds nice, but I've never once been part of team where that actually happened. Nope, the tests usually get written by the developers, so why are we making them write weird, convoluted code involving classes called "because", "before", or "it". Moq gets a pass on this one. Everyone else, just stop it.

Anyway, I like SpecsFor because it just reads like code. It's simple. Unfortunately it also seems to be dead. This project is an attempt to create a minimum viable replacement for SpecsFor, the simplest thing that works, and no more. It consists of a pair of base classes for tests, a few extensions to Shouldly, and a few very simple usage rules.

## How?
Using TestsFor is very simple. You just create test classes that inherit from one of the TestsFor base classes.

### "Tests" base class
At the root of the whole structure is the Tests base class. It does nothing more than establish some naming conventions.

### "TestsFor" base class
TestsFor expands on Tests to provide an instance of the system under test, called "SUT". By default, SUT's dependencies will be auto-mocked using Moq.AutoMocker, but that behavior can be overridden in a couple of interesting ways.

## Overriding mocking behaviors
Sometimes you want to take control over exactly what will appear in the mocking container. Maybe you want to supply one of SUT's dependencies yourself rather than using the provided auto-mock. Maybe you want complete control over the construction of the SUT. Many variations are supported, and are implemented by overriding the Given method in your test class.

### Providing dependencies
If you want to supply your own dependencies to be injected into the SUT, you only need to override the Given method, inject those dependencies into the Mocker and *then* call base.Given.

### Providing the SUT
To take complete control over the SUT is even simpler. Override Given, set up the SUT yourself, and then *don't* call base.Given. That's it. That's all there is to it.
