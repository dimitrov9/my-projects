from scipy import misc
import numpy
from scipy import misc
import numpy
import keras.models
import string
import matplotlib.pyplot as plt
from PIL import Image, ImageFilter
from scipy import ndimage

#citanje na slikata
face = misc.imread("C:/Users/dimit/Documents/Fax/Robotika 2/Data/My_Tests/W_test_cut.png",mode='L')

#maska da gi naprai beli svetlo sivite pikseli
for x in range(len(face)):
    for y in range(len(face[0])):
        if(face[x][y]>140):
            face[x][y]=255

# obid za nekoi filtri
#face = ndimage.uniform_filter(face, size=10)

#plt.imshow(face, cmap=plt.cm.gray)
#plt.show()

# invertiranje na grayscale vrednosite za da se spremi slikata za format koj sto e naucen modelot
face = numpy.invert(face)

# selektiranje na pikselite kade sto ima nesto
a = numpy.where(face > 20)
from matplotlib.patches import Rectangle
#rect = Rectangle((min(a[1]),min(a[0])), max(a[1])-min(a[1]), max(a[0])-min(a[0]), linewidth=1,edgecolor='r',facecolor='none')
#fig,ax = plt.subplots(1)
#ax.imshow(face, cmap=plt.cm.gray)
#ax.add_patch(rect)

#secenje na slikata kade sto e bukvata samo
b = face[min(a[0]):max(a[0]),min(a[1]):max(a[1])]

# resize na slikata na 20x20px
b= misc.imresize(b,(20,20))
# dodavanje padding 4px za da se naprai slikata 28x28px
b = numpy.lib.pad(b,4,'constant',constant_values=0)
#print(b.shape)
#plt.imshow(b, cmap=plt.cm.gray)
#plt.show()

#reshape vo 4D format na slikata vo zavisnost od formatot na vlezot na modelot
b = b.reshape(1,28, 28, 1).astype('float32')
# vrednostite da bidat 0-1 skaliranje
b = b / 255
# citanje na istreniraniot model
model = keras.models.load_model(r"C:\Users\dimit\PycharmProjects\Robotika2\weights.model")
# povikuvanje na predict funkcijata koja sto vrakja niza za sekoj od izlezite kolku sansi ima da e sekoj od niv
guess = model.predict(b)
# zimanje na zinata
guess = guess[0]
# zimanje na izlezot kade sto ima najdolemi sansi
a = numpy.where(guess==max(guess))
#print(a(0))
# niza od golemi latinica bukvi
Alphabet_Mapping_List = list(string.ascii_uppercase)
# formatiranje na procentot i printanje poraka za predvidenoto
chance = max(guess)*100
print("There is "+ str(round(chance,2))+ "% chance that the image is "+ Alphabet_Mapping_List[a[0][0]])