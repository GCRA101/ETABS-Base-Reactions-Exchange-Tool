Public Interface Observable

	Sub registerObserver(o As Observer)
	Sub removeObserver(o As Observer)
	Sub notifyObservers()

End Interface
