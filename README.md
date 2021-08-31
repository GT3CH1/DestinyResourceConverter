# DestinyConverter

A somewhat-ok way to convert a two or three column CSV file to a XML file used by Follett Destiny to import resources.

## Backstory

One sunny summer day, my boss came up to me and said "Hey, we're going to get an order of 330 Chromebooks. We need to
scan and add them to destiny." I winced at the fact that I would be laboring for weeks adding Chromebooks one at a time
to our inventory. I knew there was a program developed by Follet for this purpose, however, I do not have access to it.
So, I went off on an adventure on making a program to convert my massive list of Chromebooks and their MAC addresses
into a singular, dense XML file used to upload into Follett Destiny.

## How to use

Easy! Just follow the steps below.

1) Create your CSV file, with up to three columns
    1) Row 1 is the Serial Number for the item.
    2) (optional) Row 2 is the MAC address.
    3) (optional) Row 3 can be used as the District Identified.
2) Compile + Run the program
3) Select your resource type
4) Click "Browse"
5) Select your CSV file
6) Configure additional options, availabilty, condition, and purchase order
7) click "Convert"
8) If it's a success, you will have a file named `DestinyConversion.xml` in the same directory as your csv file.

## Adding more resource types

In `Resources/itemInfo.csv`, you can add as many items as you want. The format is the following:

* `<location>,<description>,<model>,<manufacturer>,<price>`
    * The `location` is found by looking at the text below "Description" in your item entry in Destiny.
    * The other fields are listed as-is in the item entry.

## Known bugs

- None known as of now, probably a ton.

## TODO

* [ ] Add releases to GitHub
* [ ] Testing
* [ ] A better way of storing resource types
* [ ] A way to save-to a location
* [ ] An icon
* [ ] Refactor the code base to make it much less ugly.

## Issue Reporting / Feature request
Please make an issue in the Issues page.