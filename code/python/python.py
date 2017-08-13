import sys
import scipy
import numpy
import warnings
from scipy.io.wavfile import read
from scipy.signal import hann
from scipy.fftpack import rfft
import matplotlib.pyplot as plt


s = [0, 1, 0, -1, 0, 1, 0, -1]
k = numpy.fft.fft(s)
d = numpy.abs(k)
print(k * 3)
print(d)


plt.plot(k)
plt.show()
