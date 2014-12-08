
from google.appengine.ext import ndb

class Player(ndb.Model):
    name = ndb.StringProperty()
    code = ndb.StringProperty()
    multiplier = ndb.FloatProperty()