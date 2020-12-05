Welcome back to Partly Cloudy! The show where you learn how to build a cloud-connected Xamarin mobile application. We start from nothing and don't quit until it's ready for the App Store!

Go ahead and download all the code from [GitHub](https://github.com/codemillmatt/partly-newsy-s1e9) - you're going to need it to follow along!

## Episode 9 Recap: Tweak It (Customizing the UI)

In this episode we put the finishing touches to the app's user interface. It looked good before, but now it'll look even better!

You'll learn all about [Xamarin.Forms Visual](https://docs.microsoft.com/xamarin/xamarin-forms/user-interface/visual/material-visual?WT.mc_id=mobile-0000-masoucou), how to change the home screen icons, tailor the splash screens to your exact specifications, and even play around with Xamarin.Forms styles. And for good measure, we'll dig down into the platform code to tweak some UI too!

### What are we going to do?

The whole point of this episode is to put little finishing touches on the app, to get things to look _exactly_ right as we get ready to deploy it to the App Stores.

So we're going to learn how Visual makes life super easy by applying predefined styling guidelines to our apps. We'll also see the super duper easy way to change out iOS icons. And maybe the biggest little change - splash screens!

#### Xamarin.Forms Visual

[Visual is an opinionated design framework](https://docs.microsoft.com/xamarin/android/user-interface/material-theme?WT.mc_id=mobile-0000-masoucou). That means somebody else has decided upon all the minute look and feel details, like padding and spacing and rounded corners for us.

And one of the cool things that comes of using Visual in Xamarin.Forms, is the resulting UI looks very similar, if not exactly the same, between iOS and Android!

So that's exactly what we did, applied some Visual goodness to our app so the buttons and shadows on the news list looked super duper good!

This is how the app looked before Visual:

![before shadow screenshot](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_800/v1583349462/Simulator_Screen_Shot_-_iPhone_11_-_2020-03-04_at_11.15.43_chppnp.png)

And after Visual:

![after show screenshot](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_800/v1583349462/Simulator_Screen_Shot_-_iPhone_11_-_2020-03-04_at_11.15.49_ansvq5.png)

I think the "flatter" look that Visual provides is _much_ better.

#### Icons and Splash Screens

What's an app without a great splash screen?

Well, we went through that in this episode too! On Android it was a bit of work, so be sure to check out the video and the [documentation](https://docs.microsoft.com/xamarin/android/user-interface/splash-screen?WT.mc_id=mobile-0000-masoucou).

iOS - a bit easier, but we had to deal with [editing the NIB file directly](https://docs.microsoft.com/xamarin/ios/user-interface/storyboards?WT.mc_id=mobile-0000-masoucou).

The end result though is pretty cool.

![splash screen screenshot](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_800/v1583349462/Simulator_Screen_Shot_-_iPhone_11_-_2020-03-04_at_11.14.44_dwcnah.png)

#### Dark Mode?!?

We didn't get to implementing dark mode in the video. But I know everybody loves dark mode. So here are some links so you can do it. Put in a pull request and let's get it implemented into the app!

* [Getting dark mode integrated into Xamarin.Forms](https://devblogs.microsoft.com/xamarin/modernizing-ios-apps-dark-mode-xamarin/?WT.mc_id=mobile-0000-masoucou)
* [iOS dark mode specifics](https://docs.microsoft.com/xamarin/ios/platform/ios13/dark-mode?WT.mc_id=mobile-0000-masoucou)
* [Android dark mode specifics](https://docs.microsoft.com/xamarin/android/platform/android-10?WT.mc_id=mobile-0000-masoucou#enhance-your-app-with-android-10-features-and-apis)

#### Styling Away

If you're going to do dark mode, you'll probably be making use of [Xamarin.Forms styles](https://docs.microsoft.com/xamarin/get-started/quickstarts/styling?WT.mc_id=mobile-0000-masoucou).

Styles is a great way to say: "Hey! I want this control to look the same everywhere, but I only want to define the look once!".

We put some styles on a `Switch` like this: 

```language-xaml
<Style TargetType="Switch">
    <Setter Property="OnColor" Value="Black" />
</Style>
````

But on Android the little knobby thing on the switch doesn't look too great - it's still pink!

![pink android switch knobby screenshot](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_800/v1583351069/Screenshot_1583350235_x4ey8c.png)

### Give Android Some More Love!

There are some properties of controls that stil need to be set on the platform. And the little knobby thing on the Android switch is one of them. :) 

It's controlled through the `styles.xml` file found within the Android project.

Specifically the `MainTheme.Base` -> `colorAccent` node within that XML file.

If you open that file up, you'll find that node is set to `@color/colorAccent.

Well ... that value for that variable is set in the Colors.xml file. So open that on up.

In there you'll see an XML node of: `<color name="colorAccent">#VALUE</color>`.

You can change that to whatever you want! I updated mine to `#880000` and now the screen looks like this.

![better looking Android screenshot](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_800/v1583351069/Screenshot_1583350695_yxxar2.png)

And as a side benefit, all of the headers on that screenshot have turned dark red too. 

*(If you really liked the pink for those headers, there are more fine grained properties to work within the Styles.xml such as `colorControlActivated` and `colorControlHighlight`.)*

### Summary

So there you have it, the UI of our app has been tweaked just a bit to make it look great for the App Store release!

And it wasn't too bad either. A little bit of Visual, a little bit of messing around with iOS XIB files and Android themes and styles... and don't forget, if you want to implement dark mode - put in a [PR at this repo](https://github.com/codemillmatt/partly-newsy-s1e9)!

In the next, and final, episode we'll be putting our app through some DevOps so we can deploy it!