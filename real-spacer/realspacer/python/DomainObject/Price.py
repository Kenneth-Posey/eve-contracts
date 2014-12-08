
from google.appengine.ext import ndb

class Price(ndb.Model):
    code = ndb.IntegerProperty()
    name = ndb.StringProperty()
    price = ndb.FloatProperty()