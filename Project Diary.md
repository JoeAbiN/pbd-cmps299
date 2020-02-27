# CMPS299 Project Diary

## Monday, February 10, 2020:

### Joe Abi Nassif: 
I read from different papers about position-based dynamics in general (main loop, idea of constraints, etc) and cloths in particular (mesh representation, constraints, etc). I also experimented with mesh creation in Unity3D using vertices and indices and read about the half-edge data structure which helps describe and iterate over meshes. 

### Mohammed Al Makdah: 
I read the parts of the research paper that explain Position Based Dynamics and understood the concept of it and the algorithm behind it, I also watched videos that explain the idea more, I looked at sample codes in unity C# that implement this idea and algorithm and got a general idea on how the code and the organization of it should look. I also learned how to create meshes in unity using triangles. 

### Hassan Faour: 
I worked with OpenMesh binaries and built an example from openmesh's tutorials. I also read the different papers, found in the below links. Working with Openmesh was challenging, I am still tinkering with the packages. I found I have alot of difficulty with the physics base of the papers, and more studies need to be done. I also created a triangle mesh on Unity following a tutorial on youtube.
https://matthias-research.github.io/pages/publications/posBasedDyn.pdf
https://pdfs.semanticscholar.org/9292/af3b97aadbd7af5b8f9ae53f45f37cf62bc4.pdf
https://www.researchgate.net/profile/Jan_Bender/publication/274940214_Position-Based_Simulation_Methods_in_Computer_Graphics/links/552cc4a40cf29b22c9c466df/Position-Based-Simulation-Methods-in-Computer-Graphics.pdf?origin=publication_detail


## Monday, February 17, 2020:

### Joe Abi Nassif:
I familiarized myself with an implementation of the Vertex, Triangle, Edge, HalfEdge, and Plane classes in Unity and created a manifold mesh of triangles using the Vertex and Triangle classes. I also studied a way to get a list of half-edges from a given list of triangles, which could be useful for iterating over a mesh and accessing various data such as edges, vertices and faces.

### Hassan Faour: 
I spent the last week trying to find an acceptable working way to get a built Openmesh object visualized in a GUI. Openmesh used the qt framework, found at https://www.qt.io/ and it was a reccomended download in the documentation. The open source pre-compiled version of qt5 is about 35GB, after raising a ticket to the IT Department asking for increased speed to download the file, the ticket was flatly rejected. As a second option, I downloaded the source files(4GB) and tried to build it myself on my Windows machine via mingw32 and a few other software dowloads (Perl, llvm, doxygen) but certain sections of qt did not compile (Most likely due to the minimalistic  nature of the Mingw32 tool). I spent 3 whole days struggling with this source code compile, thinking I would use this as a GUI. Eventually I found a stack overflow article describing how difficult it may be on windows, and that qt was not supposed to compile in this way. I tried another approach and began looking for alternative GUI interfaces. I found eventually Openflipper (Created by the same authors of Openmesh) https://www.openflipper.org/. I felt slightly silly after realizing this. After building a given tutorial Openmesh object using CMake (I used cmake GUI), the output I was seamlessly able to open on Openflipper, a really cool result after days of dissapointing results. I wanted to take it a step further though, I wanted to use the output on unity. The output is stored as a .OFF file https://en.wikipedia.org/wiki/OFF_(file_format). Unity does not import these kinds of files to be used as assets. After a bit of digging, I found a cool Opensource script to convert .OFF files into unity .asset files (and vice versa) on: https://github.com/n-yoda/unity-off. After a bit of trial and error, it worked like a charm, capping off a good week of work. Most importantly I am familiarizing myself with unity, with cmake and openmesh and the process of building an Openmesh object using a pure .cc file and turning it into something visual on the screen and even better, on unity. I created a guide on the step-by-step instructions on how I managed things, and it can be found in this repository ("How I compiled from Openmesh to work in unity").

### Mohammed Al Makdah:
I'm now familiar with the half-edge structure, and the implementations of the HalfEdge, Edge, Face, and Vertex in C++. I am now looking up into the method that hassan provided in order compile and use OpenMesh in Unity.

## Thursday, February 27, 2020:

### Joe Abi Nassif:
I programmed a simple mesh animation to get an idea on how the final physically-based animation would look like on the cloth, and began researching various physics engines and libraries which could be used in Unity to simulate position-based dynamics (e.g. Nvidia Flex). 
