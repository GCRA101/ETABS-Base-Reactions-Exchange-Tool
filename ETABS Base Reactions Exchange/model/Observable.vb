' OBSERVABLE Interface
' Interface containing the 3 methods registerObserver, removeObserver and notifyObservers that are used 
' in the Model to communicate with the View.


Public Interface Observable

	Sub registerObserver(o As Observer)
	Sub removeObserver(o As Observer)
	Sub notifyObservers()

End Interface
