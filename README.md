# Autoskill Test

Testbed for Xamrin Form projects using .netStandard2, Xamarin Forms, ReactiveUI, and FreshMVVM.

## Getting Started

Make sure to install VisualStudio. Our version is currently 2017 7.5 preview, build number: 1244.

## Deployment

If you're running on simulators existing bundleId should be fine. Else replace bundleId with your own identifier.

un: admin
pw: test

## Built With

* [XamForms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/) - Cross platform application base
* [ReactiveUI](https://reactiveui.net) - Allows RX extentions for interface elements and elegant async handling.
* [FreshMVVM](https://github.com/rid00z/FreshMvvm) - Interpage routing and data passing, as well as a good IOC system. ReactiveUI does have it's own system, but we feel that this is the more elegant solution. Highly recommend checking out their sample projects for more cool tricks.

## Contributing

We were bad kids and didn't include unit tests for the project. If any enterprising devs want to take the lead on that, you get a gold star. Otherwise, branch as needed and submit any new tricks on that new branch.

## Authors

* **K2** - *Initial work* 

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details


## Other

This project implements our basic preferred coding style. Planning on formalized a doc in the near future.

A version of this that hooks into Amazons DynmoDb and Congnito services will be in a future branch.

Apologies for the hideous colors.
