from typeids import BaseTypeIdData
class ShipTypes(object): 
    
    def findShortestString(searchString, listOfStrings):
        tempList = []
        regex = r""
        
        for item in listOfStrings:
            if str(item).find(searchString) > 0:
                tempList.append(str(item))
    
    def __init__(self):
        rawList = [x.rstrip(' ').lower() for x in BaseTypeIdData.RAW_DATA]
        
        
    
    class Ship(object):
        name
        typeid
        def __init__(self, name):
            self.name = name
            
            
            self.typeid = typeid
    
        # amarr        
        # caldari
        # gallente
        # minmatar
        # navy
        # pirate
    
    BATTLECRUISERS = [
        # amarr
          Ship("harbinger")
        , Ship("oracle")
        , Ship("prophecy")
        , Ship("prophecy blood raiders edition")
        # caldari
        , Ship("drake")
        , Ship("ferox")
        , Ship("ferox guristas edition")
        , Ship("naga")
        # gallente
        , Ship("brutix")
        , Ship("brutix serpentis edition")
        , Ship("myrmidon")
        , Ship("talos")
        # minmatar
        , Ship("cyclone")
        , Ship("cyclone thukker tribe edition")
        , Ship("hurricane")
        , Ship("tornado")
        # navy
        , Ship("brutix navy issue")
        , Ship("drake navy issue")
        , Ship("harbinger navy issue")
        , Ship("hurricane fleet issue")
    ]
    
    COMMAND_SHIPS = [
        # amarr  
          Ship("absolution")
        , Ship("damnation")
        # caldari
        , Ship("nighthawk")
        , Ship("vulture")
        # gallente
        , Ship("astarte")
        , Ship("eos")
        # minmatar
        , Ship("claymore")
        , Ship("sleipnir")
        # navy
        # pirate    
    ]
    
    BATTLESHIPS = [
        # amarr  
        Ship("abaddon")
        , Ship("abaddon kador edition")
        , Ship("abaddon tash-murkon edition")
        , Ship("apocalypse")
        , Ship("armageddon")
        # caldari
        , Ship("raven")
        , Ship("rokh")
        , Ship("rokh nugoeihuvi edition")
        , Ship("rokh wiyrkomi edition")
        , Ship("scorpion")
        # gallente
        , Ship("dominix")
        , Ship("hyperion")
        , Ship("hyperion aliastra edition")
        , Ship("hyperion innerzone shipping edition")
        , Ship("megathron")
        , Ship("megathron quafe edition")
        # minmatar
        , Ship("maelstrom")
        , Ship("maelstrom krusual edition")
        , Ship("maelstrom nefantar edition")
        , Ship("tempest")
        , Ship("typhoon")
        # navy
        , Ship("apocalypse navy issue")
        , Ship("armageddon navy issue")
        , Ship("dominix navy issue")
        , Ship("megathron navy issue")
        , Ship("raven navy issue")
        , Ship("scorpion navy issue")
        , Ship("tempest fleet issue")
        , Ship("typhoon fleet issue")
        # pirate    
        , Ship("barghest")
        , Ship("machariel")
        , Ship("nestor")
        , Ship("nightmare")
        , Ship("bhaalgorn")
        , Ship("rattlesnake")
        , Ship("vindicator")
    ]
    
    BLACK_OPS = [
        # amarr        
        Ship("redeemer")
        # caldari
        , Ship("widow")
        # gallente
        , Ship("sin")
        # minmatar
        , Ship("panther")
        # navy
        # pirate
    ]
    
    MARAUDERS = [
        # amarr        
        Ship("paladin")
        # caldari
        , Ship("golem")
        # gallente
        , Ship("kronos")
        # minmatar
        , Ship("vargur")
        # navy
        # pirate
    ]
    
    CAPITAL_INDUSTRIAL = [
        Ship("orca")
        , Ship("orca ore development edition")
        , Ship("rorqual")
        , Ship("rorqual ore development edition")
    ]
    
    CARRIERS = [
        # amarr        
        Ship("aeon")
        , Ship("archon")
        # caldari
        , Ship("chimerea")
        , Ship("wyvern")
        # gallente
        , Ship("nyx")
        , Ship("thanatos")
        # minmatar
        , Ship("hel")
        , Ship("nidhoggur")
        # navy
        # pirate
        , Ship("revenant")
    ]
    
    DREADNAUGHTS = [
        # amarr        
        Ship("revelation")
        # caldari
        , Ship("phoenix")
        # gallente
        , Ship("moros")
        # minmatar
        , Ship("naglfar")
        # navy
        # pirate
    ]
    
    FREIGHTERS = [
        # amarr        
        Ship("providence")
        # caldari
        , Ship("charon")
        # gallente
        , Ship("obelisk")
        # minmatar
        , Ship("fenrir")
        # navy
        # pirate
    ]
    
    JUMP_FREIGHTERS = [
        # amarr        
        Ship("ark")
        # caldari
        , Ship("rhea")
        # gallente
        , Ship("anshar")
        # minmatar
        , Ship("nomad")
        # navy
        # pirate
    ]
    
    TITANS = [
        # amarr        
        Ship("avatar")
        # caldari
        , Ship("leviathan")
        # gallente
        , Ship("erebus")
        # minmatar
        , Ship("ragnarok")
        # navy
        # pirate
    ]
    
    CRUISERS = [
        # amarr        
        Ship("arbitrator")
        , Ship("augoror")
        , Ship("maller")
        , Ship("omen")
        , Ship("omen kador edition")
        , Ship("omen tash-murkon edition")
        # caldari
        , Ship("blackbird")
        , Ship("caracal")
        , Ship("caracal nugoeihuvi edition")
        , Ship("caracal wiyrkomi edition")
        , Ship("moa")
        , Ship("osprey")
        # gallente
        , Ship("celestis")
        , Ship("exequror")
        , Ship("thorax")
        , Ship("thorax aliastra edition")
        , Ship("thorax innerzone shipping edition")
        , Ship("vexor")
        # minmatar
        , Ship("bellicose")
        , Ship("rupture")
        , Ship("scythe")
        , Ship("stabber")
        , Ship("stabber krusual edition")
        , Ship("stabber nefantar edition")
        # navy
        , Ship("augoror navy issue")
        , Ship("caracal navy issue")
        , Ship("exequror navy issue")
        , Ship("omen navy issue")
        , Ship("osprey navy issue")
        , Ship("scythe fleet issue")
        , Ship("stabber fleet issue")
        , Ship("vexor navy issue")
        # pirate
        , Ship("ashimmu")
        , Ship("cynabal")
        , Ship("orthrus")
        , Ship("phantasm")
        , Ship("stratios")
        , Ship("gila")
        , Ship("vigilant")
    ]
    
    HEAVY_ASSAULT_CRUISERS = [
        # amarr        
        Ship("sacrilege")
        , Ship("zealot")
        # caldari
        , Ship("cerberus")
        , Ship("eagle")
        # gallente
        , Ship("deimos")
        , Ship("ishtar")
        # minmatar
        , Ship("muninn")
        , Ship("vagabond")
        # navy
        # pirate
    ]
    
    HEAVY_INTERDICTION_CRUISERS = [
        # amarr     
        Ship("devoter")
        # caldari
        , Ship("onyx")
        # gallente
        , Ship("phobos")
        # minmatar
        , Ship("broadsword")
        # navy
        # pirate
    ]
    
    LOGISTICS = [
        # amarr        
        Ship("guardian")
        # caldari
        , Ship("basilisk")
        # gallente
        , Ship("oneiros")
        # minmatar
        , Ship("scimitar")
        # navy
        # pirate
    ]
    
    RECON_SHIPS = [
        # amarr        
        Ship("curse")
        , Ship("pilgrim")
        # caldari
        , Ship("falcon")
        , Ship("rook")
        # gallente
        , Ship("arazu")
        , Ship("lachesis")
        # minmatar
        , Ship("huginn")
        , Ship("rapier")
        # navy
        # pirate
    ]
    
    STRATEGIC_CRUISERS = [
        # amarr        
        Ship("legion")
        # caldari
        , Ship("tengu")
        # gallente
        , Ship("proteus")
        # minmatar
        , Ship("loki")
        # navy
        # pirate
    ]
    
    DESTROYERS = [
        # amarr        
        Ship("coercer")
        , Ship("coercer blood raiders edition")
        , Ship("dragoon")
        # caldari
        , Ship("corax")
        , Ship("cormorant")
        , Ship("cormorant guristas edition")
        # gallente
        , Ship("algos")
        , Ship("catalyst")
        , Ship("catalyst serpentis edition")
        # minmatar
        , Ship("talwar")
        , Ship("thrasher")
        , Ship("thrasher thukker tribe edition")
        # navy
        # pirate
    ]
    
    INTERDICTORS = [
        # amarr        
        Ship("heretic")
        # caldari
        , Ship("flycatcher")
        # gallente
        , Ship("eris")
        , Ship("sabre")
        # minmatar
        # navy
        # pirate
    ]
    
    FRIGATES = [
        Ship("venture")
        # amarr        
        , Ship("crucifier")
        , Ship("executioner")
        , Ship("inquisitor")
        , Ship("magnate")
        , Ship("punisher")
        , Ship("punisher kador edition")
        , Ship("punisher tash-murkon edition")
        , Ship("tormentor")
        # caldari
        , Ship("bantam")
        , Ship("condor")
        , Ship("griffin")
        , Ship("heron")
        , Ship("kestrel")
        , Ship("merlin")
        , Ship("merlin nugoeihuvi edition")
        , Ship("merlin wiyrkomi edition")
        # gallente
        , Ship("atron")
        , Ship("imicus")
        , Ship("incursus")
        , Ship("incursus aliastra edition")
        , Ship("incursus innerzone shipping edition")
        , Ship("maulus")
        , Ship("navitas")
        , Ship("tristan")
        # minmatar
        , Ship("breacher")
        , Ship("burst")
        , Ship("probe")
        , Ship("rifter")
        , Ship("rifter krusual edition")
        , Ship("rifter nefantar edition")
        , Ship("slasher")
        , Ship("vigil")
        # navy
        , Ship("caldari navy hookbill")
        , Ship("federation navy comet")
        , Ship("police pursuit comet")
        , Ship("republic fleet firetail")
        # pirate
        , Ship("astero")
        , Ship("cruor")
        , Ship("daredevil")
        , Ship("dramiel")
        , Ship("garmur")
        , Ship("succubus")
        , Ship("worm")
    ]
    
    ASSAULT_FRIGATES = [
        # amarr        
        Ship("retribution")
        , Ship("vengeance")
        # caldari
        , Ship("harpy")
        , Ship("hawk")
        # gallente
        , Ship("enyo")
        , Ship("ishkur")
        # minmatar
        , Ship("jaguar")
        , Ship("wolf")
        # navy
        # pirate
    ]
    
    COVERT_OPS = [
        # amarr  
        Ship("anathema")
        , Ship("purifier")
        # caldari
        , Ship("buzzard")
        , Ship("manticore")
        # gallente
        , Ship("helios")
        , Ship("nemesis")
        # minmatar
        , Ship("cheetah")
        , Ship("hound")
        # navy
        # pirate
    ]
    
    ELECTRONIC_ATTACK_FRIGATES = [
        # amarr        
        Ship("sentinel")
        # caldari
        , Ship("kitsune")
        # gallente
        , Ship("keres")
        # minmatar
        , Ship("hyena")
        # navy
        # pirate
    ]
    
    INTERCEPTORS = [
        # amarr        
        Ship("crusader")
        , Ship("malediction")
        # caldari
        , Ship("crow")
        , Ship("raptor")
        # gallente
        , Ship("ares")
        , Ship("taranis")
        # minmatar
        , Ship("claw")
        , Ship("stiletto")
        # navy
        # pirate
    ]
    
    EXPEDITION_FRIGATES = [
        Ship("prospect")
    ]
    
    TRANSPORT_SHIPS = [
        # amarr        
        Ship("impel")
        , Ship("prorator")
        # caldari
        , Ship("bustard")
        , Ship("crane")
        # gallente
        , Ship("viator")
        , Ship("occator")
        # minmatar
        , Ship("mastadon")
        , Ship("prowler")
        # navy
        # pirate
    ]
    
    INDUSTRIAL_SHIPS = [
        Ship("noctis")
        # amarr        
        , Ship("bestower")
        , Ship("bestower tash-murkon edition")
        , Ship("sigil")
        # caldari
        , Ship("badger")
        , Ship("tayra")
        , Ship("tayra wiyrkomi edition")
        # gallente
        , Ship("epithal")
        , Ship("iteron inner zone shipping edition")
        , Ship("iteron mark v")
        , Ship("kyros")
        , Ship("miasmos")
        , Ship("nereus")
        # minmatar
        , Ship("hoarder")
        , Ship("mammoth")
        , Ship("mammtho nefantar edition")
        , Ship("wreathe")
        # navy
        # pirate
    ]
    
    EXHUMERS = [
        Ship("mackinaw ore development edition")
        , Ship("hulk")
        , Ship("mackinaw")
        , Ship("skiff")
    ]
    
    MINING_BARGE = [
        Ship("covetor")
        , Ship("procurer")
        , Ship("retriever")
    ]
    
    
    