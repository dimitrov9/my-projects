from keras.models import Sequential
from keras.layers import Dense
from keras.layers import Dropout
from keras.layers import Flatten
from keras.layers.convolutional import Conv2D
from keras.layers.convolutional import MaxPooling2D
from keras import backend as K
from keras.utils import np_utils
from sklearn.model_selection import train_test_split
import numpy as np

# seed so vrednost od brojot na koloni za da vadi isti rezultati
seed = 785
np.random.seed(seed)

# vcituravanje na datasetot od csv filot
dataset = np.loadtxt('D:\ROBOTIKA2\A_Z HandwrittenData.csv', delimiter=',')

# delenje na podatocite na input output
X = dataset[:,0:784]
Y = dataset[:,0]

# delenje na podatocite na pola za trening i test
(X_train, X_test, Y_train, Y_test) = train_test_split(X, Y, test_size=0.50, random_state=seed)

# od 1D (2D so brojot na primeroci ) niza i pretvaranje na 4D ( prvoto e br na primeroci, posle 2D za slikata 28x28px
# 1 e deka 1 axis ima za grayscale (3 ako e egb) i castiranje vo float za da ima decimali za skaliranje
X_train = X_train.reshape(X_train.shape[0], 28, 28, 1).astype('float32')
X_test = X_test.reshape(X_test.shape[0], 28, 28, 1).astype('float32')

# delenje so max vrednosta, za vrednostite da bidat od 0-1
X_train = X_train / 255
X_test = X_test / 255

# one hot encode outputs
# enkodiranje na ouputite
Y_train = np_utils.to_categorical(Y_train)
Y_test = np_utils.to_categorical(Y_test)

#broj na klasi (outputi)
num_classes = Y_test.shape[1]


# kretiranje na Sequential keras model
model = Sequential()
# deklariranje input shape so 32 batch size
# 5x5 K matrica za konvoluciskoto matpiranje
# input shape e 28x28px so 1 za grayscale vrednostite
# aktivaciska funkcija na izlezot na ovoj layer e relu koja sto e rampa 0 e za negativni y=1*x za pozitivni
model.add(Conv2D(32, (5, 5), input_shape=(28, 28, 1), activation='relu'))
# pravi pooling go deli brojot na nevroni na  inputot za 2 vo 2te oski
model.add(MaxPooling2D(pool_size=(2, 2)))
# kolkav procent na primeroci da otvrli vo sekoj ciklus na ucenjeto za da se izbegne overfitting
model.add(Dropout(0.2))
# od multidimenzionalen shape od predhodnite layeri go pretvara vo 1D za polesno procesiranje
model.add(Flatten())
# dodavanje use eden layer za ucenje so 128 nevroni(izlezi od layerot) so aktivackiska funkcija relu x+
model.add(Dense(128, activation='relu'))
# num_classes broj na izlezi od ovoj layer t.e. 25 za sekoja bukva
# soft max e slicna na sigmod
# sumata na sekoj od izlezite kje bide 0
# ovaa funkcija vrakja float kade sto e procent za sekoj od izlezite
# kolku sansi e inputot za sekoj od izlezite ( pr. 0 = 0.60,1 = 0.39 i 0.01 za site ostanati izlezi )
model.add(Dense(num_classes, activation='softmax'))

# Kompajliranje na modelot so loss funkcija kako sto e podole taa se koristi za klasifikacija
# adam optimizer kade sto gradientot go presmetuva na ponizok red i e dosta posporo ucenjeto za podobri rezultati
# metrics = accuracy e pozelno za klasifikacija ( tocnost>brzina)
model.compile(loss='categorical_crossentropy', optimizer='adam', metrics=['accuracy'])
# treniranje na modelot
# 10 pati na cela dataset - epochs
# batch size na kolku primeroci da uci ( zima 200 go uci posle zima dr 200 pa pak go uci itn.)
# verbose za da ni prikazuva do kaj e epochs
model.fit(X_train, Y_train, validation_data=(X_test, Y_test), epochs=10, batch_size=200, verbose=2)

# Krajna evaluacija na modelot za da ni izvadi razultati kolku dobro e naucan
scores = model.evaluate(X_test,Y_test, verbose=0)
print("CNN Error: %.2f%%" % (100-scores[1]*100))

# zacuvuvanje na modelot
model.save('weights.model')